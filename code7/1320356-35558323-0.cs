    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    
    [System.Serializable]
    public class Cabeza
    {
    	public string Id;
    	public string UrlOBJ;
    	public string UrlTextura;
    	public string PathOBJbajado;
    	public string PathTexturaBajada;
    
    	public Cabeza (string nuevoId)
    	{
    		Id = nuevoId;
    		UrlOBJ =  nuevoId +".obj";
    		UrlTextura =  nuevoId + ".png";
    	}
    }
