    interface IProcessOutput
    {
      IReadOnlyCollection<string> Cerr { get; }
      IReadOnlyCollection<string> Cout { get; }
      void OnError(string text);
      void OnOutput(string text);
    }
