    byte[] image = GetMyImage();
    StreamWriter.WriteLine("HTTP/1.0 200 OK");
    StreamWriter.WriteLine("Content-Type: image/jpeg");
    StreamWriter.WriteLine("Content-Length: " + image.Length);
    StreamWriter.WriteLine("");
    StreamWriter.Write(image, 0, image.Length);
