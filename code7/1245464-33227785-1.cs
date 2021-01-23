    public class Form1
    {
        public int[,] histogramaAcumulado(Bitmap bmp)
        {
            //Creamos una matriz que contendrá el histograma acumulado
            byte Rojo = 0;
            byte Verde = 0;
            byte Azul = 0;
            //Declaramos tres variables que almacenarán los colores
            int[,] matrizAcumulada = new int[3, 256];
            //Recorremos la matriz
            for (i = 0; i <= bmp.Width - 1; i++)
            {
                for (j = 0; j <= bmp.Height - 1; j++)
                {
                    Rojo = bmp.GetPixel(i, j).R;
                    //Asignamos el color
                    Verde = bmp.GetPixel(i, j).G;
                    Azul = bmp.GetPixel(i, j).B;
                    //ACumulamos los valores. 
                    matrizAcumulada[0, Rojo] += 1;
                    matrizAcumulada[1, Verde] += 1;
                    matrizAcumulada[2, Azul] += 1;
                }
            }
            return matrizAcumulada;
        }
        //Variable que almacenará los histogramas
        int[,] histoAcumulado;
        private void Form1_Load(object sender, EventArgs e)
        {
            //Cargamos los histogramas
            Bitmap bmp = new Bitmap(PictureBox1.Image);
            histoAcumulado = histogramaAcumulado(bmp);
            //Ejecutamos el botón del histograma rojo
            Button1_Click(sender, e);
        }
        //Histograma rojo
        private void Button1_Click(object sender, EventArgs e)
        {
            //Borramos el posible contenido del chart
            Chart1.Series("Histograma").Points.Clear();
            //Los ponesmos del colores correspondiente
            Chart1.Series("Histograma").Color = Color.Red;
            for (i = 0; i <= 255; i++)
            {
                Chart1.Series("Histograma").Points.AddXY(i + 1, histoAcumulado[0, i]);
            }
        }
        //Histograma verde
        private void Button2_Click(object sender, EventArgs e)
        {
            //Borramos el posible contenido del chart
            Chart1.Series("Histograma").Points.Clear();
            Chart1.Series("Histograma").Color = Color.Green;
            for (i = 0; i <= 255; i++)
            {
                Chart1.Series("Histograma").Points.AddXY(i + 1, histoAcumulado[1, i]);
            }
        }
        //Histograma azul
        private void Button3_Click(object sender, EventArgs e)
        {
            //Borramos el posible contenido del chart
            Chart1.Series("Histograma").Points.Clear();
            Chart1.Series("Histograma").Color = Color.Blue;
            for (i = 0; i <= 255; i++)
            {
                Chart1.Series("Histograma").Points.AddXY(i + 1, histoAcumulado[2, i]);
            }
        }
        public Form1()
        {
            Load += Form1_Load;
        }
    }
