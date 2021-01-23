        using (StreamReader infil = new StreamReader("saying.txt"))
        {
            inValue = infil.ReadLine();
            while (inValue != null)
            {
                this.lstBxDisplay.Items.Add(inValue);
                inValue = infil.ReadLine();
            } // end of while
        } // end of using
