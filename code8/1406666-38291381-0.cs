    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Microsoft.Speech.Recognition;
    using System.Globalization;
    using NAudio.Wave;
    using System.IO;
    using System.IO.Pipes;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            SpeechRecognitionEngine sre;
            WaveIn wi;
            SpeechStreamer ss;
    
            public Form1()
            {
                InitializeComponent();
    
                WaveCallbackInfo callbackInfo = WaveCallbackInfo.FunctionCallback();
                wi = new WaveIn(callbackInfo);
                ss = new SpeechStreamer(100000);
                wi.DataAvailable += wi_DataAvailable;
                wi.StartRecording();
    
                CultureInfo ci = new CultureInfo("en-us");
                sre = new SpeechRecognitionEngine(ci);
                // The default format for WaveIn is 8000 samples/sec, 16 bit, 1 channel
                Microsoft.Speech.AudioFormat.SpeechAudioFormatInfo safi = new Microsoft.Speech.AudioFormat.SpeechAudioFormatInfo(8000, Microsoft.Speech.AudioFormat.AudioBitsPerSample.Sixteen, Microsoft.Speech.AudioFormat.AudioChannel.Mono);
                sre.SetInputToAudioStream(ss, safi);
                GrammarBuilder gb = new GrammarBuilder("Hello");
                sre.LoadGrammarAsync(new Grammar(gb));
                sre.SpeechRecognized += sre_SpeechRecognized;
                sre.RecognizeAsync(RecognizeMode.Multiple);
            }
    
            void wi_DataAvailable(object sender, WaveInEventArgs e)
            {
                ss.Write(e.Buffer, 0, e.BytesRecorded);
            }
    
            void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
            {
                listBox1.Items.Add(DateTime.Now.ToString() + " " + e.Result.Text);
            }
        }
    }
