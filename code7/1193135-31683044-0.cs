    public class Manifest
    {
        // other properties
        int VersionMajor { get; set; }
        int VersionMinor { get; set; }
        int VersionBuild { get; set; }
        int VersionRevision { get; set; }
        public Version Version 
        {
            get 
            { 
                return new Version(VersionMajor, VersionMinor, VersionBuild, VersionRevision); 
            }
            set
            {
                VersionMajor = value.Major;
                VersionMinor = value.Minor;
                VersionBuild = value.Build;
                VersionRevision = value.Revision;
            }
        }
    }
     
