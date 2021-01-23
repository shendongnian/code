        public static void MoveNode(string ear, int frequency)
        {
            int circleRef = 0;
            switch (frequency)
            {
                case 250:
                    if (ear == "right")
                    {
                        circleRef = 12;
                    }
                    else if (ear == "left")
                    {
                        circleRef = 0;
                    }
                    break;
                case 500:
                    if (ear == "right")
                    {
                        circleRef = 13;
                    }
                    else if (ear == "left")
                    {
                        circleRef = 1;
                    }
                    break;
            }
            var circles = Driver.Instance.FindElements(By.TagName("circle"));
            circles[circleRef].Click();
            //add logic for dragging and releasing
        }
        
