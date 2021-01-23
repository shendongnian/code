            foreach (var item in filebox1)
            {
                System.IO.File.Move(item, Path.Combine(destdir, Path.GetFileName(item)));
                ++counter;
                int tmp = (int)((counter* 100) / totfiles);
                bgw.ReportProgress(tmp, "File transfered : " + Path.GetFileName(item));
                Thread.Sleep(100);
            }
