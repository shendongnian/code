    using System.IO;
    using Tamir.SharpSsh;
    using Tamir.SharpSsh.jsch;
    string ip = "DestinationIp";
    string user = "JohnDoe";
    string password = "YourPassword";
    Sftp sftp = new Tamir.SharpSsh.Sftp(ip, user, password);
    sftp.Connect();
    FileInfo yourFileInfo = new FileInfo("path");
