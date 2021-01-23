            using (reader)
            {
                var text = reader.ReadToEnd();
                // Text is found between > and < tags
                for (int i = 0; i < text.Length - 1; i++)
                {
                    // Find first and last index of the substring to be extracted
                    if (text[i] == '>' && text[i + 1] != '<')
                    {
                        int textFirstIndex = i + 1;
                        // Handle border case
                        if (textFirstIndex == text.Length - 1)
                        {
                            sb.Append(text.Substring(textFirstIndex, 1));
                            break;
                        }
                        int textLastIndex = text.IndexOf('<', textFirstIndex + 1);
                        // Extract substring
                        sb.AppendLine(text.Substring(textFirstIndex, textLastIndex - textFirstIndex));
                        i = textLastIndex;
                    }
                }
            }
            Console.WriteLine(sb.ToString().TrimEnd());
