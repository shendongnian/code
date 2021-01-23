            Directory.CreateDirectory(@"C:\Users\" + userName + "\\Documents\\Alexis Custom Commands");
            Settings.Default.ShellC = @"C:\Users\" + userName + "\\Documents\\Alexis Custom Commands\\Shell Commands.txt";
            Settings.Default.ShellR = @"C:\Users\" + userName + "\\Documents\\Alexis Custom Commands\\Shell Response.txt";
            Settings.Default.ShellL = @"C:\Users\" + userName + "\\Documents\\Alexis Custom Commands\\Shell Location.txt";
            Settings.Default.WebC = @"C:\Users\" + userName + "\\Documents\\Alexis Custom Commands\\Web Commands.txt";
            Settings.Default.WebR = @"C:\Users\" + userName + "\\Documents\\Alexis Custom Commands\\Web Response.txt";
            Settings.Default.WebL = @"C:\Users\" + userName + "\\Documents\\Alexis Custom Commands\\Web URL.txt";
            Settings.Default.SocC = @"C:\Users\" + userName + "\\Documents\\Alexis Custom Commands\\Social Commands.txt";
            Settings.Default.SocR = @"C:\Users\" + userName + "\\Documents\\Alexis Custom Commands\\Social Response.txt";
            Settings.Default.Save();
            scpath = Settings.Default.ShellC;
            srpath = Settings.Default.ShellR;
            slpath = Settings.Default.ShellL;
            webcpath = Settings.Default.WebC;
            webrpath = Settings.Default.WebR;
            weblpath = Settings.Default.WebL;
            socpath = Settings.Default.SocC;
            sorpath = Settings.Default.SocR;
            if (!File.Exists(scpath))
            { sw = File.CreateText(scpath); sw.Write("My Documents"); sw.Close(); }
            if (!File.Exists(srpath))
            { sw = File.CreateText(srpath); sw.Write("Right away"); sw.Close(); }
            if (!File.Exists(slpath))
            { sw = File.CreateText(slpath); sw.Write(@"C:\Users\" + userName + "\\Documents"); sw.Close(); }
            if (!File.Exists(webcpath))
            { sw = File.CreateText(webcpath); sw.Write("Open Google"); sw.Close(); }
            if (!File.Exists(webrpath))
            { sw = File.CreateText(webrpath); sw.Write("Very well"); sw.Close(); }
            if (!File.Exists(weblpath))
            { sw = File.CreateText(weblpath); sw.Write("http://www.google.com"); sw.Close(); }
            if (!File.Exists(socpath))
            { sw = File.CreateText(socpath); sw.Write("How are you"); sw.Close(); }
            if (!File.Exists(sorpath))
            { sw = File.CreateText(sorpath); sw.Write("I'm doing well thanks for asking"); sw.Close(); }
            ArrayShellCommands = File.ReadAllLines(scpath);
            ArrayShellResponse = File.ReadAllLines(srpath);
            ArrayShellLocation = File.ReadAllLines(slpath);
            ArrayWebCommands = File.ReadAllLines(webcpath);
            ArrayWebResponse = File.ReadAllLines(webrpath);
            ArrayWebURL = File.ReadAllLines(weblpath);
            ArraySocialCommands = File.ReadAllLines(socpath);
            ArraySocialResponse = File.ReadAllLines(sorpath);
            try
            { shellcommandgrammar = new Grammar(new GrammarBuilder(new Choices(ArrayShellCommands))); _recognizer.LoadGrammarAsync(shellcommandgrammar); }
            catch
            { Alexis.SpeakAsync("I've detected an in valid entry in your computer commands, possibly a blank line. Computer commands will cease to work until it is fixed."); }
            try
            { webcommandgrammar = new Grammar(new GrammarBuilder(new Choices(ArrayWebCommands))); _recognizer.LoadGrammarAsync(webcommandgrammar); }
            catch
            { Alexis.SpeakAsync("I've detected an in valid entry in your web commands, possibly a blank line. Web commands will cease to work until it is fixed."); }
            try
            { socialcommandgrammar = new Grammar(new GrammarBuilder(new Choices(ArraySocialCommands))); _recognizer.LoadGrammarAsync(socialcommandgrammar); }
            catch
            { Alexis.SpeakAsync("I've detected an in valid entry in your social commands, possibly a blank line. Social commands will cease to work until it is fixed."); }
           
        }
