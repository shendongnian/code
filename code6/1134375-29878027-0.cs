    public void CanSignSimple()
    {
    	Key bob = new Key();
    	Transaction tx = new Transaction();
    	tx.Inputs.Add(new TxIn()
    	{
    		ScriptSig = bob.ScriptPubKey
    	});
    	tx.Sign(bob, false);
    }
