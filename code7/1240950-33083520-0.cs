        private void CopyAFile()
        {
            var source = new OpenFileDialog();
            if (source.ShowDialog().GetValueOrDefault())
            {
                var dest = new SaveFileDialog();
                if (dest.ShowDialog().GetValueOrDefault())
                {
                    File.Copy(source.FileName, dest.FileName);
                }
            }
        }
