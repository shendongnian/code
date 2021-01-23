            int lRows = fs.NumRows();
            for (int i = 0; i < lRows; i++)
            {
                // Get the feature
                IFeature pFeat = fs.GetFeature(i); 
                StringBuilder sb = new StringBuilder();
                {
                    sb.Append(Guid.NewGuid().ToString());
                    sb.Append("|");
                    sb.Append(pFeat.DataRow["MAPA"]);
                    sb.Append("|");
                    sb.Append(pFeat.BasicGeometry.ToString());
                }
                pLinesList.Add(sb.ToString());
                lCnt++;
                if (lCnt % 10 == 0)
                {
                    pOld = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("\r{0} de {1} ({2}%)", lCnt.ToString(), lRows.ToString(), (100.0 * ((float)lCnt / (float)lRows)).ToString());
                    Console.ForegroundColor = pOld;
                }
            }
