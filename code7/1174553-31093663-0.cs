    using System;
    using System.Diagnostics;
    using System.Threading;
    using NAudio.Dsp;
    using NAudio.Wave;
    ...
    protected void Button1_Click(object sender, EventArgs e)
    {
      var waveFilename = @"c:\Windows\Media\tada.wav";
      /* Trying to play the .wav file on the main thread
         doesn't seem to work. */
      ThreadPool.QueueUserWorkItem(
        (state) =>
        {
          using (var audioPlayback = new AudioPlayback())
          {
            audioPlayback.Load(waveFilename);
            audioPlayback.Play(); // Asynchronous.
            /* Need to sleep for the approximate length of .wav file,
               otherwise no sound is produced because of the
               asynchronous Play() call. */
            Thread.Sleep(2000);
          }
        });
    }
