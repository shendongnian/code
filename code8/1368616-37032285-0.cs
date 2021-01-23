     private void Button_Click(object sender, RoutedEventArgs e)
        {
            double[,] initialArray = new double[3, 4] { { 5, 1, 9, 3 }, { 7, 8, 6, 4 }, { 2, 4, 9, 5 } };
            string rowOfInts = "";
            string columnsAndRow = "";
            for (int r = 0; r < initialArray.GetLength(0); r++)
            {
                string tempString = "";
                double inttotal = 0;
                for (int c = 0; c < initialArray.GetLength(1); c++)
                {
                    rowOfInts = tempString + " " + initialArray[r, c];
                    tempString = rowOfInts;
                    inttotal += initialArray[r, c];
                }
                columnsAndRow = columnsAndRow + rowOfInts + " row total of = " + inttotal.ToString() + "\n";
            }
            txtbx.Text = Convert.ToString(columnsAndRow);
        }
