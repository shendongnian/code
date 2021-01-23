    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Win32;
    using System.Windows.Media;
    
    namespace Music_Player
    {
        class Offnen : MainWindow
        {
            public void OffnenDerDatei(MediaPlayer mp)
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.DefaultExt = ".mp3";
                dlg.Filter = "MP3 files (*.mp3)|*.mp3|M4A files (*.m4a)|*.m4a|All files (*.*)|*.*";
                if (dlg.ShowDialog() == true)
                {
                    mp.Open(new Uri(dlg.FileName));
                    //labelsong.Content = dlg.SafeFileName; // fyi this variable looks to be undeclared
                }
            }
        }
    }
