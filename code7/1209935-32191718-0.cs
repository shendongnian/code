    string PNGPath = Path.ChangeExtension(Loan_list[f], ".png");
    string PDFfile = PNGPath.Replace("png", "pdf");
    string PNGfile = PNGPath;
    Process process = new Process();
    process.StartInfo.FileName = @"C:\Program Files\ImageMagick-6.9.2 Q16\convert.exe";
    process.StartInfo.Arguments = "\"" + PDFfile + "\"" +" \"" + PNGPath +"\""; // Note the /c command (*)
    process.StartInfo.UseShellExecute = false;
    process.StartInfo.RedirectStandardOutput = true;
    process.StartInfo.RedirectStandardError = true;
    process.Start();
    //* Read the output (or the error)
    string output = process.StandardOutput.ReadToEnd();
    Console.WriteLine(output);
    string err = process.StandardError.ReadToEnd();
    Console.WriteLine(err);
    process.WaitForExit();
