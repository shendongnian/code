    using (StreamReader srdInput = File.OpenText(dlgOpen.FileName))
    {
        while (!srdInput.EndOfStream)
        {
            string line1 = srdInput.ReadLine();
            string line2 = srdInput.ReadLine();
            //Insert line1 into the first ListBox and line2 into the second listBox
        }
    }
