                string line = engSR.ReadLine();
                string[] arr = line.Split('|');
                int numberOfLines = int.Parse(arr[1]) + 1;
                englishFile.Seek(0, SeekOrigin.Begin);
                engSW.WriteLine("*|{0}", numberOfLines);
                arabicFile.Seek(0, SeekOrigin.Begin);
                arabSW.WriteLine("*|{0}", numberOfLines);
                engSW.Flush();
                arabSW.Flush();
                englishFile.Seek(0, SeekOrigin.End);
                line = engSR.ReadLine();
                engSW.WriteLine("{0}|{1}", numberOfLines, englishin.Text);
                arabicFile.Seek(0, SeekOrigin.End);
                line = arabSR.ReadLine();
                arabSW.WriteLine("{0}|{1}", numberOfLines, arabicin.Text);
            }
            catch
            {
            }
            finally
            {
                engSW.Close();
                arabSW.Close();
                arabSR.Close();
                engSR.Close();
                arabicFile.Close();
                englishFile.Close();
            } 
