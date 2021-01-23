        public String testing(String ab, String cd)
        {
            //Count the number of times the method is called
            ++counter;
            //Write it to a text file
            File.WriteAllText(@"C:\Users\ken4ward\Desktop\Tidy\WriteLines.txt", counter.ToString());
            //Read from that text file
            //String Readfiles = File.ReadAllText(@"C:\Users\ken4ward\Desktop\Tidy\WriteLines.txt");
            //Convert to integer
            //Int32 myInt = Int32.Parse(Readfiles);
            Int32 myInt = counter;
            //Store in array variable
            String start = myInt.ToString() + ab + cd;
            //Stor the new data in the array
            Array.Resize(ref lines, lines.Length + 1);
            lines[lines.GetUpperBound(0)] = start;
            //Write into another text file on new lines
            File.WriteAllLines(@"C:\Users\ken4ward\Desktop\Tidy\Writing.txt", lines);
            //String gb = ab; String th = cd;
            String you = ab + cd;
            return you;   
        }
