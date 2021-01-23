    public B(Object Obj)
            : base()
        {
    		swich (Obj.GetType())
    		{
    			Case DataType1:
    			this.Edit = Edit_1;
    			break;
    			Case DataType2:
    			this.Edit = Edit_2;
                default:
                throw new Exception("Object Type [" + Obj.GetType().FullName + "] not supported");
    		}
        }
