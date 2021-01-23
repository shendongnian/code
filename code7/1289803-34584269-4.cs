            var lines = System.IO.File.ReadAllLines("Your text file");
            lines[0] = TextBoxCardname1.text);
            System.IO.File.WriteAllLines("Your text file", lines);
            var lines = System.IO.File.ReadAllLines("Your text file");
            lines[1] = TextBoxCardname2.text);
            System.IO.File.WriteAllLines("Your text file", lines);
            var lines = System.IO.File.ReadAllLines("Your text file");
            lines[2] = TextBoxCardname3.text);
            System.IO.File.WriteAllLines("Your text file", lines);
        //...etc
