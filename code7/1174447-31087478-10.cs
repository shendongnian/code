        public static void Traverse(int channelToAccess, int maxChannels, params char[] brokenButtons)
        {      
            int result = -1;      // closest channel num
            for (int i = 1; result == -1 && i > 0 && i < maxChannels; i++)
            {
                if (!(channelToAccess + i).ToString().Any(brokenButtons.Contains)) { result = channelToAccess + i; break; }
                if (!(channelToAccess - i).ToString().Any(brokenButtons.Contains)) { result = channelToAccess - i; break; }
            }
           int difference = result - channelToAccess;
           Console.WriteLine("To open channel {0} you should turn channel {1} and press {2} button {3} times", channelToAccess, result, difference > 0 ? "Prev" : "Next", Math.Abs(difference));
        }
