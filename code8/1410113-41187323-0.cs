    bool commentStarted = false, commentEnds = false;
foreach (string line in scriptAllLines)
					{
						 if (line.Contains("/*"))
						{
							commentStarted = true;
							commentEnds = false;
						}
						if (line.Contains("*/"))
						{
							commentEnds = true;
							commentStarted = false;
						}
}
