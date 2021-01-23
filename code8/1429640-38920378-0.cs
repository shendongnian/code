        try
        {
            if (Element[1] == "xpath")
            {
                Wait(Element, null);
                element = driver.FindElement(By.XPath(Element[0]));
                findCounter = 0;
            }
            else if (Element[1] == "id")
            {
                Wait(Element, null);
                element = driver.FindElement(By.Id(Element[0]));
                findCounter = 0;
            }
            else if (Element[1] == "linktext")
            {
                Wait(Element, null);
                element = driver.FindElement(By.LinkText(Element[0]));
                findCounter = 0;                   
            }
        }
        catch (StaleElementReferenceException e)
        {
            Console.Out.WriteLine("Attempting to recover from StaleElementReferenceException ...");
            Sleep(250);
            findCounter++;
            Find(Element, Text);
        }
        catch (NullReferenceException e)
        {
            //break point here.
        }
