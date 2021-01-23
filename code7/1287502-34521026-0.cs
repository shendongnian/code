	class i2c
	{
		const int I2C_SLAVE = 0x0703;
		const int I2C_SLAVE_FORCE = 0x0706;
		int fd_write;
		int fd_read;
		string i2c_bus_file;
		public i2c (int device, String bus)
		{
			i2c_bus_file = String.Format ("/dev/i2c-{0}", bus);
			fd_write = Syscall.open (i2c_bus_file, OpenFlags.O_WRONLY, FilePermissions.DEFFILEMODE);
			// need to check Syscall.GetLastError()
			fd_read = Syscall.open (i2c_bus_file, OpenFlags.O_RDONLY, FilePermissions.DEFFILEMODE);
			// need to check Syscall.GetLastError()
            // I2C_SLAVE or I2C_SLAVE_FORCE if already in use...
			Syscall.fcntl (fd_read, I2C_SLAVE, device);
			// need to check Syscall.GetLastError()
			Syscall.fcntl (fd_write, I2C_SLAVE, device);
			// need to check Syscall.GetLastError()
		}
		public Errno write (byte[] data)
		{
			Syscall.write (fd_write, data, data.Length); 
			return Syscall.GetLastError ();
		}
		public Errno read (ref byte[] data)
		{
			Syscall.read (fd_read, data, data.Length);
			return Syscall.GetLastError ();
		}
		public void close ()
		{
			Syscall.close (fd_write);
			Syscall.close (fd_read);
		}
	}
