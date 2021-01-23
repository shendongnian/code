    public Form31683555 ( )
    {
      InitializeComponent();
      // control expansion
      this.tlv.CanExpandGetter = delegate(object x)
      {
        if (x is Sistem)
          return !ObjectListView.IsEnumerableEmpty((x as Sistem).Devices);
        else if (x is Location)
          return !ObjectListView.IsEnumerableEmpty((x as Location).Systems);
        else if (x is Device)
          return false;
        else
          throw new ArgumentException("x");
      };
      // node children
      this.tlv.ChildrenGetter = delegate(object x) {
        if (x is Sistem)
          return (x as Sistem).Devices;
        else if (x is Location)
          return (x as Location).Systems;
        else if (x is Device)
          return null;
        else
          throw new ArgumentException("x");
      };
      // TreeListView first order parent level
      this.tlv.Roots = new Location[] { 
        new Location { 
          Systems = new Sistem[] { 
            new Sistem { 
              Devices = new Device[] { 
                new Device { ObjectName = "Device 1.1.1", ObjectType="some device"},
                new Device { ObjectName = "Device 1.1.2", ObjectType="a device"}
              },
              ObjectName = "System 1.1", ObjectType = "system"
            },
            new Sistem { 
              Devices = new Device[] { 
                new Device { ObjectName = "Device 1.2.1", ObjectType="device"},
                new Device { ObjectName = "Device 1.2.2", ObjectType="another device"}
              },
              ObjectName = "System 1.2", ObjectType = "another system"
            },            
          },
          ObjectType = "location 1", ObjectName="full location"
        },
        new Location {ObjectName = "empty", ObjectType="location"}
      };
    }
