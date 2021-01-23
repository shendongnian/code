    public class UserOptions
    {
      public UserOptions()
      {
        // Set defaults
        AbsolutePressPreference = AbsolutePressOption.psi;
      }
      public AbsolutePressOption AbsolutePressPreference { get; set; }
      public FluidFlowOption FluidFlowPreference { get; set; }
    }
