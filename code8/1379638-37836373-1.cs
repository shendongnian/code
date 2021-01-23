    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Numerics;
    using MathNet.Numerics.IntegralTransforms;
    using MathNet.Numerics.Signals;
    using MathNet.Filtering;
    namespace MFCC
    {
    class MFCC_calculating
    {
        public double[] frame;        //один фрейм
        public double[,] frame_mass;  //массив всех фреймов по 2048 отсчетов или 128 мс        
        public Complex[,] frame_mass_FFT;     //массив результатов FFT для всех фреймов
        int[] filter_points = {6,18,31,46,63,82,103,127,154,184,218,
                                  257,299,348,402,463,531,608,695,792,901,1023};//массив опорных точек для фильтрации спекрта фрейма
        double[,] H = new double[20, 1024];     //массив из 20-ти фильтров для каждого MFCC
        double[] MFCC = new double[20];     //массив MFCC для данной речевой выборки   <<<<<<<<<<<<<<<<<<<<
        /// <summary>
        /// Функция для расчета MFCC для сигнала с частотой дискретизации 16кГц
        /// </summary>
        /// <param name="wav_PCM">Массив значений амплитуд аудиосигнала</param>
        /// <returns>Массив из 20-ти MFCC</returns>
        public double[] MFCC_20_calculation(double[] wav_PCM)
        {
            int count_frames = (wav_PCM.Length * 2 / 2048) + 1; //количество отрезков в сигнале
            RMS_gate(wav_PCM);          //применение noise gate
            Normalize(wav_PCM);         //нормализация
            frame_mass = Set_Frames(wav_PCM);       //формирование массива фреймов
            Hamming_window(frame_mass, count_frames);        //окно Хэмминга для каждого отрезка
            frame_mass_FFT = FFT_frames(frame_mass, count_frames);       //FFT для каждого фрейма
            double[,] MFCC_mass = new double[count_frames, 20];         //массив наборов MFCC для каждого фрейма
            //***********   Расчет гребенчатых фильтров спектра:    *************
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 1024; j++)
                {
                    if (j < filter_points[i]) H[i, j] = 0;
                    if ((filter_points[i] <= j) & (j <= filter_points[i + 1]))
                        H[i, j] = ((double)(j - filter_points[i]) / (filter_points[i + 1] - filter_points[i]));
                    if ((filter_points[i + 1] <= j) & (j <= filter_points[i + 2]))
                        H[i, j] = ((double)(filter_points[i + 2] - j) / (filter_points[i + 2] - filter_points[i + 1]));
                    if (j > filter_points[i + 2]) H[i, j] = 0;
                }
            for (int k = 0; k < count_frames; k++)
            {
                //**********    Применение фильтров и логарифмирование энергии спектра для каждого фрейма   ***********
                double[] S = new double[20];
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 1024; j++)
                    {
                        S[i] += Math.Pow(frame_mass_FFT[k, j].Magnitude, 2) * H[i, j];
                    }
                    if (S[i] != 0) S[i] = Math.Log(S[i], Math.E);
                }
                //**********    DCT и массив MFCC для каждого фрейма на выходе     ***********
                for (int l = 0; l < 20; l++)
                    for (int i = 0; i < 20; i++) MFCC_mass[k, l] += S[i] * Math.Cos(Math.PI * l * ((i * 0.5) / 20));
            }
            //***********   Рассчет конечных MFCC для всей речевой выборки    ***********       
            for (int i = 0; i < 20; i++)
            {
                for (int k = 0; k < count_frames; k++) MFCC[i] += MFCC_mass[k, i];
                MFCC[i] = MFCC[i] / count_frames;
            }
            return MFCC;
        }
        /// <summary>
        /// Функция для подавления шума по среднекравратичному уровню
        /// </summary>
        /// <param name="wav_PCM">Массив значений амплитуд аудиосигнала</param>
        private void RMS_gate(double[] wav_PCM)
        {
            int k = 0;
            double[] buf_rms = new double[50];
            double RMS = 0;
            for (int j = 0; j < wav_PCM.Length; j++)
            {
                if (k < 100)
                {
                    RMS += Math.Pow((wav_PCM[j]), 2);
                    k++;
                }
                else
                {
                    if (Math.Sqrt(RMS / 100) < 0.005)
                        for (int i = j - 100; i <= j; i++) wav_PCM[i] = 0;
                    k = 0; RMS = 0;
                }
            }
        }
        /// <summary>
        /// Функция нормализации сигнала
        /// </summary>
        /// <param name="wav_PCM">Массив значений амплитуд аудиосигнала</param>
        private void Normalize(double[] wav_PCM)
        {
            double[] abs_wav_buf = new double[wav_PCM.Length];
            for (int i = 0; i < wav_PCM.Length; i++)
                if (wav_PCM[i] < 0) abs_wav_buf[i] = -wav_PCM[i];   //приводим все значения амплитуд к абсолютной величине 
                else abs_wav_buf[i] = wav_PCM[i];                    //для определения максимального пика
            double max = abs_wav_buf.Max();
            double k = 1f / max;        //получаем коэффициент нормализации            
            for (int i = 0; i < wav_PCM.Length; i++)    //записываем нормализованные значения в исходный массив амплитуд
            {
                wav_PCM[i] = wav_PCM[i] * k;              
            }
        }
        /// <summary>
        /// Функция для формирования двумерного массива отрезков сигнала длиной по 128мс.
        /// При этом начало каждого следующего отрезка делит предыдущий пополам
        /// </summary>
        /// <param name="wav_PCM">Массив значений амплитуд аудиосигнала</param>
        private double[,] Set_Frames(double[] wav_PCM)
        {
            double[,] frame_mass_1;  //массив всех фреймов по 2048 отсчетов или 128 мс
            int count_frames = 0;       
            int count_samp = 0;
            frame_mass_1 = new double[(wav_PCM.Length*2 / 2048) + 1, 2048];
            for (int j = 0; j < wav_PCM.Length; j++)
            {
                if (j >= 1024)      //запись фреймов в массив
                {
                    count_samp++;
                    if (count_samp >= 2049)
                    {
                        count_frames += 2;
                        count_samp = 1;
                    }
                    frame_mass_1[count_frames, count_samp - 1] = wav_PCM[j - 1024];
                    frame_mass_1[count_frames + 1, count_samp - 1] = wav_PCM[j];
                }
            }
            return frame_mass_1;
        }
        /// <summary>
        /// Оконная функция Хэмминга
        /// </summary>
        /// <param name="frames">Двумерный массив отрезвов аудиосигнала</param>
        /// <param name="wav_PCM">Массив значений амплитуд аудиосигнала</param>
        private void Hamming_window(double[,] frames, int count_frames)
        {
            double omega = 2.0 * Math.PI / (2048f);
            for (int i = 0; i < count_frames; i++)
                for (int j = 0; j < 2048; j++)
                    frames[i, j] = (0.54 - 0.46 * Math.Cos(omega * (j))) * frames[i, j];
        }
        /// <summary>
        /// Быстрое преобразование фурье для набора отрезков
        /// </summary>
        /// <param name="frames">Двумерный массив отрезвов аудиосигнала</param>
        /// <param name="wav_PCM">Массив значений амплитуд аудиосигнала</param>
        private Complex[,] FFT_frames(double[,] frames, int count_frames)
        {
            Complex[,] frame_mass_complex =
                new Complex[count_frames, 2048]; //для хранения результатов FFT каждого фрейма в комплексном виде
            Complex[] FFT_frame = new Complex[2048];     //спектр одного фрейма
            for (int k = 0; k < count_frames; k++)
            {
                for (int i = 0; i < 2048; i++) FFT_frame[i] = frames[k, i];
                Transform.FourierForward(FFT_frame, FourierOptions.Matlab);
                for (int i = 0; i < 2048; i++) frame_mass_complex[k, i] = FFT_frame[i];
            }
            return frame_mass_complex;
        }
    }
    }
