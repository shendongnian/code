        double DTW_improved(Sequence input, Sequence template)
        {
            // Don't compare two sequences if one of their lengths is half the other's
            if (input.Frames.Length <= (0.5 * template.Frames.Length) || template.Frames.Length <= (0.5 * input.Frames.Length))
                return double.PositiveInfinity;
            int rows = template.Frames.Length, columns = input.Frames.Length;
            double[] c1 = new double[rows];
            double[] c2 = new double[rows];
            double[] temp; // To hold address only (use it in swapping address) 
            c1[0] = distance(input.Frames[0], template.Frames[0]);
            for (int i = 1; i < rows; i++)
                c1[i] = c1[i - 1] + distance(input.Frames[0], template.Frames[i]);
            for (int i = 1; i < columns; i++)
            {
                c2[0] = distance(input.Frames[i], template.Frames[0]) + c1[0];
                c2[1] = distance(input.Frames[i], template.Frames[1]) + Math.Min(c1[0], c1[1]); 
                // Calculating first 2 elements of the array before the loop
                //since they both need special conditions
                for (int j = 2; j < rows; j++)
                    c2[j] = Math.Min(c1[j], Math.Min(c1[j - 1], c1[j - 2])) + distance(input.Frames[i], template.Frames[j]);
                if (i != columns - 1) // Swapping addresses of c1 & c2
                {
                    temp = c2;
                    c2 = c1;
                    c1 = temp;
                }
            }
            return c2[rows - 1] / (0.5 * (input.Frames.Length + template.Frames.Length)); // Normalization: Dividing edit distance by average of input length & template length
        }
