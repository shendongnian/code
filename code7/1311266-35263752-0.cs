            while (start <= end)
            {
                if (oddNum(start))
                {
                    oddSum += start;
                    oddCount++;
                }
                else
                {
                    evenSum += start;
                    evenCount++;
                }
                totalSum += start;
                productNum *= start;
                avrgNum = totalSum / end;
                avrgSum = avrgNum / totalSum;
                start++;
             }
           
