    using Microsoft.Speech.Recognition;
    using System.Reflection;
    namespace DTMF_Recognition
    {
        class Program
        {
            static void Main(string[] args)
            {
                Grammar grammar = null;
                grammar = new Grammar("PinGrammar.xml");
                DtmfRecognitionEngine dre = new DtmfRecognitionEngine();
                dre.DtmfRecognized += dre_DtmfRecognized;
                FieldInfo field = typeof(DtmfRecognitionEngine).GetField("_engine", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance);
                var wrapper = field.GetValue(dre);
                FieldInfo engineField = wrapper.GetType().GetField("_engine", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance);
                SpeechRecognitionEngine sre = (SpeechRecognitionEngine)engineField.GetValue(wrapper);
                dre.DtmfHypothesized += dre_DtmfHypothesized;
                dre.DtmfRecognitionRejected += dre_DtmfRecognitionRejected;
                dre.RecognizeCompleted += dre_RecognizeCompleted;
                dre.LoadGrammar(grammar);
                //dre.AddTone(DtmfTone.One);
                //dre.AddTone(DtmfTone.Two);
                //dre.AddTone(DtmfTone.Three);
                //dre.AddTone(DtmfTone.Four);
                //dre.AddTone(DtmfTone.Hash);
                sre.SetInputToWaveFile(@"C:\Users\Clay Ver Valen\Desktop\3.wav");
                sre.SpeechHypothesized += sre_SpeechHypothesized;
                sre.SpeechDetected += sre_SpeechDetected;
                sre.SpeechRecognitionRejected += sre_SpeechRecognitionRejected;
                dre.RecognizeAsync();
                System.Threading.Thread.Sleep(30000);
            }
            static void sre_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
            {
                int i = 1;
            }
            static void sre_SpeechHypothesized(object sender, SpeechHypothesizedEventArgs e)
            {
                int i = 1;
            }
            static void sre_SpeechDetected(object sender, SpeechDetectedEventArgs e)
            {
                int i = 1;
            }
            static void dre_DtmfRecognitionRejected(object sender, DtmfRecognitionRejectedEventArgs e)
            {
                int i = 1;
            }
            static void dre_DtmfHypothesized(object sender, DtmfHypothesizedEventArgs e)
            {
                int i = 1;
            }
            static void dre_RecognizeCompleted(object sender, DtmfRecognizeCompletedEventArgs e)
            {
                int i = 1;
            }
            static void dre_DtmfRecognized(object sender, DtmfRecognizedEventArgs e)
            {
                int i = 1;
            }
        }
    }
