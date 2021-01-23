            double[] monthsAsDoubles = new double[Month.Length];
            for (int i = 0; i < monthsAsDoubles.Length; i++)
            {
                monthsAsDoubles[i] = MonthToDouble(Month[i]);
            }
            QuickSort(monthsAsDoubles);
