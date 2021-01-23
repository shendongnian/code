            int maxChannels = 450;
            char[] invalidNums = { '2', '5', '8', '9' };
            int yournumber = 255; // your test number
            int result = -1;      // closest channel num
            for (int i = 1; result == -1 && i > 0 && i < maxChannels; i++)
            {
                if (!(yournumber + i).ToString().Any(invalidNums.Contains)) { result = yournumber + i; break; }
                if (!(yournumber - i).ToString().Any(invalidNums.Contains)) { result = yournumber + i; break; }
            }
