     public void ConvertToHexa(int number)
            {
                if (number == 0)
                    return;
                ConvertToHexa(number / 16);
                var remainder = number % 16;
                Console.Write(remainder >= 10 ? ((char)(remainder - 10 + 'A')).ToString() : remainder.ToString());
            }
