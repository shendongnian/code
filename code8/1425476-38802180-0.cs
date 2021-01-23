    using System.IO;
    using System.Runtime.InteropServices.WindowsRuntime;
    var stream = audioBytes.AsBuffer().AsStream().AsRandomAccessStream();
    mediaElement.SetSource(stream, "audio/x-wav");
    mediaElement.Play();
