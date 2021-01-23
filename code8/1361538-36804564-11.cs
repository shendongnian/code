    public abstract class DeviceVersion {
      // What type is this?
      public virtual DeviceType DeviceType { get; }
      // Common Properties and Methods, etc here
      #region Function Availability Properties
      bool CanFastForward { get; }
      bool CanPlay { get; }
      bool CanStop { get; }
      bool Can... { get; }
      ...
      #endregion
      #region Methods
      bool Connect(string ipAddress, string user, string password);
      void Disconnect();
      void Play();
      void Stop();
      ...
      #endregion
    }
