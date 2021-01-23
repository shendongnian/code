    DeviceWatcher midiWatcher;
    void MonitorMidiChanges()
    {
      if (midiWatcher != null)
        return;
      var selector = MidiInPort.GetDeviceSelector();
      midiWatcher = DeviceInformation.CreateWatcher(selector);
      midiWatcher.Added += (s, a) => Debug.WriteLine("Midi Port named '{0}' with Id {1} was added", a.Name, a.Id);
      midiWatcher.Updated += (s, a) => Debug.WriteLine("Midi Port with Id {1} was updated", a.Id);
      midiWatcher.Removed += (s, a) => Debug.WriteLine("Midi Port with Id {1} was removed", a.Id);
      midiWatcher.EnumerationCompleted += (s, a) => Debug.WriteLine("Initial enumeration complete; watching for changes...");
      midiWatcher.Start();
    }
