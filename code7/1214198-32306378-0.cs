    //Because that naming is ridiculous
    using ItemMoveEventHandler = Outlook.MAPIFolderEvents_12_BeforeItemMoveEventHandler; 
    using ItemMoveEvent = Outlook.MAPIFolderEvents_12_Event;
    //Used to wrap multiple arguments into a single object
    public class MyMoveEventArgs {
      public MyMoveEventArgs(Object item, MAPIFolder folder) {
        this.Item = item;
        this.Folder = folder;
      }
    
      public Object Item {get; private set;}
      public MAPIFolder Folder {get; private set;}
    }
    //Create an extension method
    public static IObservable<MyMoveEventArgs> BeforeMoveObservable(
      this ItemMoveEvent folder, 
      Func<object, MAPIFolder, bool> shouldCancel) {
    
        return Observable.FromEvent<ItemMoveEventHandler, 
                                  MoveEventArgs>
                        //Use the conversion overload
                        (emit => new ItemMoveEventHandler(
                              //The compiler seems to complain about cancel
                              //being implicit, so explicitly declare your params
                              (object item, MAPIFolder f, out bool cancel) => 
                              {
                                //cancel needs to be set somewhere in the body
                                if (!(cancel = shouldCancel(item, f)) {
                                 emit(new MyMoveEventArgs(item, f));
                                }
                              }
                        },
                        h => folder.BeforeItemMove += h,
                        h => folder.BeforeItemMove -= h);
    
    }
