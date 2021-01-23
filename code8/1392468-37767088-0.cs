        private static void startLRM(int i)
        {
            Console.WriteLine(i);
            lrm[i].Text = "LRM R" + ((port / 10) - 120).ToString() + " S" + a.ToString();
            a++;
            Console.WriteLine(array[i]);
            lrm[i].capacity = array[i];
            lrm[i].available = array[i];
            lrm[i].WriteCapacity(lrm[i].capacity);
            lrm[i].WriteAvailable(lrm[i].available);
            lrm[i].ShowDialog();
        }
