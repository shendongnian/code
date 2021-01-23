    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace WindowsFormsApplication3
    {
        public partial class Form1 : Form
        {
            [DllImport("user32.dll")]
            public static extern Boolean GetLastInputInfo(ref tagLASTINPUTINFO plii);
            public struct tagLASTINPUTINFO
            {
                public uint cbSize;
                public Int32 dwTime;
            }
            public Form1()
            {
                InitializeComponent();
                timer1.Start();
            }        
            private void Form1_Load(object sender, EventArgs e)
            {
                axWindowsMediaPlayer1.Ctlenabled = true;
                var pl = axWindowsMediaPlayer1.playlistCollection.newPlaylist("XYZ");
                p1.appendItem(axWindowsMediaPlayer1.newMedia(@"C:\Folder\file1.mp4"));
                pl.appendItem(axWindowsMediaPlayer1.newMedia(@"C:\Folder\file2.mp4"));
                axWindowsMediaPlayer1.currentPlaylist = pl;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }            
            private void timer1_Tick(object sender, EventArgs e)
            {
                tagLASTINPUTINFO LastInput = new tagLASTINPUTINFO();
                Int32 IdleTime;
                LastInput.cbSize = (uint)Marshal.SizeOf(LastInput);
                LastInput.dwTime = 0;
                if (GetLastInputInfo(ref LastInput))
                {
                    IdleTime = System.Environment.TickCount - LastInput.dwTime;
                    if (IdleTime > 10000)
                    {
                        axWindowsMediaPlayer1.Ctlcontrols.pause();
                        timer1.Stop();
                        MessageBox.Show("Do you wish to continue?");
                    }
                    timer1.Start();
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                }
            }
        }
    }
