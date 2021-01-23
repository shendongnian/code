    class MyDataWrapper<T>
    {
    	public T Data { set; get; }
    }
----------
	var dicData = new Dictionary<int, MyDataWrapper<string>>();
	dicData[0] = new MyDataWrapper<string> { Data = "0" };
	dicData[1] = new MyDataWrapper<string> { Data = "0" };
	var myDic = new ReadOnlyDictionary<int, MyDataWrapper<string>>(dic);
	myDic[1].Data = "2";
	
	// myDic[1] = new ... compile error
	// myDic.Add() compile error
