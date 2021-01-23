        var bbb = new EventLogWatcher("Microsoft-Windows-AppLocker/EXE and DLL");
        bbb.EventRecordWritten += Bbb_EventRecordWritten;
        bbb.Enabled = true;
...
            private void Bbb_EventRecordWritten(object sender, EventRecordWrittenEventArgs e)
            {
                var eventAsXml = e.EventRecord.ToXml();
                var eventAsString = e.EventRecord.FormatDescription();
            }
