     public int CountArrow(String main)
        {
            int result = 0;
            try
            {
                String arrow1 = ">>-->";
                String arrow2 = "<--<<";
                for (int i = 0; i < main.Length; i++)
                {
                    if (main.IndexOf(arrow1,i) == i)
                        result++;
                    if (main.IndexOf(arrow2,i) == i)
                        result++;
                }
            }
            catch (Exception exception)
            {
            }
            return result;
        }
