            ArrayList arraylist1 = new ArrayList();
            arraylist1.Add(5);
            arraylist1.Add(7);
            //create the second arraylist
            ArrayList arraylist2 = new ArrayList();
            arraylist2.Add("Five");
            arraylist2.Add("Seven");
            //perform AddRange method
            arraylist1.AddRange(arraylist2);
            // Display the values.
            foreach (object i in arraylist1)
            {
                Console.WriteLine(i);
            }
        }
    }
}
