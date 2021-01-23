    using System.Collections.Generic;
    
    public enum TKeyIdentity
    {
    	_A, _B, _C, _D, _E, _F, _G, _H, _I, _J, _K, _L, _M, _N, _O, _1, _2, _3
    }
    
    public class TraverseKeyPaths
    {
    	public readonly List<List<TKeyIdentity>> keyPad = new List<List<TKeyIdentity>>()
    	{
    		new List<TKeyIdentity> {TKeyIdentity._H, TKeyIdentity._L},
    		new List<TKeyIdentity> {TKeyIdentity._I, TKeyIdentity._K, TKeyIdentity._M},
    		new List<TKeyIdentity> {TKeyIdentity._F, TKeyIdentity._J, TKeyIdentity._L, TKeyIdentity._N},
    		new List<TKeyIdentity> {TKeyIdentity._G, TKeyIdentity._M, TKeyIdentity._O},
    		new List<TKeyIdentity> {TKeyIdentity._H, TKeyIdentity._N}
    	};
    
    	public readonly List<TKeyIdentity> keyPadRoot = new List<TKeyIdentity>() { TKeyIdentity._A, TKeyIdentity._B, TKeyIdentity._C, TKeyIdentity._D, TKeyIdentity._E, TKeyIdentity._F, TKeyIdentity._G, TKeyIdentity._H, TKeyIdentity._I, TKeyIdentity._J, TKeyIdentity._K, TKeyIdentity._L, TKeyIdentity._M, TKeyIdentity._N, TKeyIdentity._O, TKeyIdentity._1, TKeyIdentity._2, TKeyIdentity._3 };
    
    	public TraverseKeyPaths(List<TKeyIdentity> keyPath, int pressesRemaining, int vowelsAllowed)
    	{
    		foreach (var pressedKey in keyPath)
    		{
    			int value = new TraverseKeyPaths(keyPad[(int)pressedKey], pressesRemaining, vowelsAllowed - isVowel[pressedKey]);
    		}
    	}
    }
