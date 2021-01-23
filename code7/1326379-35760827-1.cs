	dictionary_Object.IfContainsKeyThenExecute("Name", (k, v) =>
	{
		string ipconnection = GetIPConnectionName(dictionary_Object);
        //Do something with ipconnection
	});
	
	dictionary_Object.IfContainsKeyThenExecute("TCPIPPort", (k, v) => { /* Do Something */ });
	dictionary_Object.IfContainsKeyThenExecute("TCPIPAddress", (k, v) => { /* Do Something */ });
	dictionary_Object.IfContainsKeyThenExecute("DefaultProViewNXGAddress", (k, v) => { /* Do Something */ });
	
	dictionary_Object.IfContainsKeyThenExecute("Comms_TimeOut", (k, v) => Another_Dictionary[k] = v);
	dictionary_Object.IfContainsKeyThenExecute("Comms_Retries", (k, v) => Another_Dictionary[k] = v);
	dictionary_Object.IfContainsKeyThenExecute("FW_File_Retries", (k, v) => Another_Dictionary[k] = v);
