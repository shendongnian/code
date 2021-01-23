            int[] sortArray = new int[listBox2.Items.Count];
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                sortArray[i] = Convert.ToInt16(listBox2.Items[i]);
            }
            int aantal = listBox2.Items.Count;
            listBox2.Items.Clear();
            Array.Sort(soorteerArray);
            
            
            foreach (int value in sortArray)
            {
                listBox2.Items.Add(value);
            }
