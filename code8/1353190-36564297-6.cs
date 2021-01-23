     static void districtCounter(int livingIn)
        {
            if (livingIn <= 0 && livingIn >= 23)
            {
                cancel();
            }
            else
                dist[livingIn] += 1;
        }
