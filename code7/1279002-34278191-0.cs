    using System;
    using System.Media;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            [DllImport("winmm.dll", EntryPoint = "waveOutGetVolume")]
            private static extern int WaveOutGetVolume(IntPtr hwo, out uint dwVolume);
            [DllImport("winmm.dll", EntryPoint="waveOutSetVolume")]
            private static extern int WaveOutSetVolume(IntPtr hwo, uint dwVolume);
            private SoundPlayer player = new SoundPlayer();
            // a crude delta time field
            private float totalElapsedTime;
            // tweak this value to determine how quickly you want the fade to happen
            private const float Velocity = 0.001f;
            public Form1()
            {
                this.InitializeComponent();
                // i was using 100 milliseconds as my "frame rate"
                this.timer1.Interval = 100;
                this.stopButton.Enabled = false;
            }
            private void startButton_Click(object sender, EventArgs e)
            {
                // sets the audio device volume to the max.
                // this is not the computer's volume so it won't
                // blast out your ear drums by doing this unless you
                // have the computer volume super high - which is not this
                // code's fault
                WaveOutSetVolume(IntPtr.Zero, uint.MaxValue);
                this.startButton.Enabled = false;
                this.stopButton.Enabled = true;
                this.totalElapsedTime = 0f;
                this.player.SoundLocation = @"Music File.wav";
                this.player.Load();
                this.player.Play();
            }
            private void stopButton_Click(object sender, EventArgs e)
            {
                // being the stop
                this.timer1.Start();
                this.stopButton.Enabled = false;
            }
            private void timer1_Tick(object sender, EventArgs e)
            {
                // amount to interpolate (value between 0 and 1 inclusive)
                float amount = Math.Min(1f, this.totalElapsedTime * Velocity);
                // the new channel volume after a lerp
                float lerped = Lerp(ushort.MaxValue, 0, amount);
                // each channel's volume is actually represented as a ushort
                ushort channelVolume = (ushort)lerped;
                // the new volume for all the channels
                uint volume = (uint)channelVolume | ((uint)channelVolume << 16);
                // sets the volume 
                WaveOutSetVolume(IntPtr.Zero, volume);
                // checks if the interpolation is finished
                if (amount >= 1f)
                {
                    // stop the timer 
                    this.timer1.Stop();
                    // stop the player
                    this.player.Stop();
                    // stop is complete so let user start again
                    this.startButton.Enabled = true;
                }
                // add the elapsed milliseconds (very crude delta time)
                this.totalElapsedTime += this.timer1.Interval;
            }
            public static float Lerp(float value1, float value2, float amount)
            {
                // does a linear interpolation
                return (value1 + ((value2 - value1) * amount));
            }
        }
    }
