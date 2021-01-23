    private WriteableBitmap m_wbmpLaImagen;
    public MainWindow()
    {
        InitializeComponent();
    }
    private void button_load_1_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog ofd = new OpenFileDialog();
        ofd.FileName = "Imagen";
        ofd.DefaultExt = ".bmp";
        ofd.Filter = "Mapas de bits|*.bmp";
        Nullable<bool> result = ofd.ShowDialog();
        if (result == true)
        {
            BitmapImage bmpi = new BitmapImage(); //JpegBitmapEncoder alternativa
            bmpi.BeginInit();
            bmpi.UriSource = new Uri(ofd.FileName);
            bmpi.EndInit();
            m_wbmpLaImagen = new WriteableBitmap(bmpi);
            laimagen1.Source = m_wbmpLaImagen;
        }
    }
    private void button_load_2_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog ofd = new OpenFileDialog();
        ofd.FileName = "Imagen";
        ofd.DefaultExt = ".bmp";
        ofd.Filter = "Mapas de bits|*.bmp";
        Nullable<bool> result = ofd.ShowDialog();
        if (result == true)
        {
            BitmapImage bmpi = new BitmapImage(); //JpegBitmapEncoder alternativa
            bmpi.BeginInit();
            bmpi.UriSource = new Uri(ofd.FileName);
            bmpi.EndInit();
            m_wbmpLaImagen = new WriteableBitmap(bmpi);
            laimagen2.Source = m_wbmpLaImagen;
        }
    }
    private void button_do_processing_Click(object sender, RoutedEventArgs e)
    {
        WriteableBitmap imagen1bmp;
        WriteableBitmap imagen2bmp;
        WriteableBitmap imgcom;
        int x, y;
        Color col3 = new Color();
        imagen1bmp = (WriteableBitmap)laimagen1.Source;
        imagen2bmp = (WriteableBitmap)laimagen2.Source;
        imgcom = new WriteableBitmap(imagen1bmp);
        imgcom.Lock();// Prepare BackBuffer for writing;
        for (y = 0; y < imagen1bmp.PixelHeight; y++)
        {
            for (x = 0; x < imagen1bmp.PixelWidth; x++)
            {
                // Get both colors in the pixel point
                Color col1 = readPixel(imagen1bmp, x, y);
                Color col2 = readPixel(imagen2bmp, x, y);
                // the color for the output image for this pixel
                if (col1.R > col2.R)
                    col3.R = col1.R;
                else
                    col3.R = col2.R;
                if (col1.G > col2.G)
                    col3.G = col1.G;
                else
                    col3.G = col2.G;
                if (col1.B > col2.B)
                    col3.B = col1.B;
                else
                    col3.B = col2.B;
                if (col1.A > col2.A)
                    col3.A = col1.A;
                else
                    col3.A = col2.A;
                writepixel(imgcom, x, y, col3.R, col3.G, col3.B, col3.A);
            }
            UpdateLayout();
        }
        imgcom.Unlock();// Release BackBuffer from writing;
        UpdateLayout();
        imgcombined.Source = imgcom;
    }
    private static int[] randomNumber()
    {
        Random rand = new Random();
        int[] nums = new int[20];
        for (int x = 0; x < 1; x++)
        {
            nums[x] = rand.Next();
        }
        return nums;
    }
    private void writepixel(WriteableBitmap ElWriteableBitmap, int iCoordX, int iCoordY, byte bRojo, byte bVerde, byte bAzul, byte bAlfa)
    {
        unsafe
        {
            int *ipTempBackBuffer = (int *)ElWriteableBitmap.BackBuffer;
            ipTempBackBuffer += (iCoordY * ElWriteableBitmap.PixelWidth) + iCoordX;
            int color_data = bAlfa << 24; // Canal alfa
            color_data |= bRojo << 16; // Componente rojo
            color_data |= bVerde << 8; // Componente verde
            //color_data = color_data & (bVerde << 8);
            color_data |= bAzul << 0;  // Componente azul 
            *ipTempBackBuffer = color_data;
        }
    }
    private System.Windows.Media.Color readPixel(WriteableBitmap ElWriteableBitmap, int iCoordX, int iCoordY)
    {
        System.Windows.Media.Color colorResultante = new System.Windows.Media.Color();
        unsafe
        {
            int *ipTempBackBuffer = (int *)ElWriteableBitmap.BackBuffer;
            ipTempBackBuffer += (iCoordY * ElWriteableBitmap.PixelWidth) + iCoordX;
            colorResultante.A = ((byte *)ipTempBackBuffer)[3];
            colorResultante.R = ((byte *)ipTempBackBuffer)[2];
            colorResultante.G = ((byte *)ipTempBackBuffer)[1];
            colorResultante.B = ((byte *)ipTempBackBuffer)[0];
        }
        return colorResultante;
    }
