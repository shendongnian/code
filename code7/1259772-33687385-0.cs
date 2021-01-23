        private void btnWhileLoop_Click(object sender, EventArgs e)
        {
            int r = 0; //row
            int c = 0; //column
            int intResult;
            string strSpace;
            txtTable.Clear();    //clear the text box
            txtTable.Refresh();  //refresh the form before exiting the method
            Thread.Sleep(1000);  //wait one second to see the clear text box
            //Outer loop goes down the rows
             r = 1; //initialize r
            do
            {
                //Inner loop goes across the columns
                c = 1; //initialize c
                do
                {
                    intResult = r * c;
                    c++;  //increment c
                    txtTable.AppendText(" "); // insert space
                    txtTable.AppendText(intResult.ToString());  //insert result
                } while (c < 10);
                txtTable.AppendText("\r\n");  //Move down one line
                r++;  //increment r
            } while (r < 10);
        }
