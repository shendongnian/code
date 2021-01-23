    Vector start = segment.GetStartPoint();
            Vector end = segment.GetEndPoint();
            bool firstRender = result.Length == 0;
            bool hardReturn = false;
            if (!firstRender)
            {
                Vector x0 = start;
                Vector x1 = lastStart;
                Vector x2 = lastEnd;
                float dist = (x2.Subtract(x1)).Cross((x1.Subtract(x0))).LengthSquared / x2.Subtract(x1).LengthSquared;
                float sameLineThreshold = 1f; // we should probably base this on the current font metrics, but 1 pt seems to be sufficient for the time being
                if (dist > sameLineThreshold)
                    hardReturn = true;
            }
            if (hardReturn)
            {
                //AppendTextChunk('\n');
                AppendTextChunk(' ');
            }
            else if (!firstRender)
            {
                if (result[result.Length - 1] != ' ' && renderInfo.GetText().Length > 0 && renderInfo.GetText()[0] != ' ')
                {
                    // we only insert a blank space if the trailing character of the previous string wasn't a space, and the leading character of the current string isn't a space
                    float spacing = lastEnd.Subtract(start).Length;
                    if (spacing > renderInfo.GetSingleSpaceWidth() / 2f)
                    {
                        AppendTextChunk(' ');
                    }
                }
            }
