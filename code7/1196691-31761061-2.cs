    public void writeChecklistToFile()
    {
       // Open file for writing once..
       using (var checklistWriter = new StreamWriter(File.OpenWrite(getChecklistFile())))
       {
          // .. write everything to it, using the same Stream
          checklistWriter.WriteLine("Pre-Anaesthetic Checklist\n");
          writeAnimalDetails(checklistWriter);
          writeAnimalHistory(checklistWriter);
          writeAnimalExamination(checklistWriter);
          writeDrugsCheck(checklistWriter);
       }
       // And the file is really closed here, thanks to using/Dispose
    }
