    using UnityEngine;
    using UnityEditor;
    using System.Collections;
    using System.IO;
    public class RenderCubemapWizard : ScriptableWizard
    {
    public Transform renderFromPosition;
    public Cubemap cubemap;
    void OnWizardUpdate()
    {
        string helpString = "Select transform to render from and cubemap to render into";
        bool isValid = (renderFromPosition != null) && (cubemap != null);
    }
    void OnWizardCreate()
    {
        // create temporary camera for rendering
        GameObject go = new GameObject("CubemapCamera");
        go.AddComponent<Camera>();
        // place it on the object
        go.transform.position = renderFromPosition.position;
        go.transform.rotation = Quaternion.identity;
        // render into cubemap		
        go.GetComponent<Camera>().RenderToCubemap(cubemap);
        // destroy temporary camera
        DestroyImmediate(go);
        ConvertToPng();
    }
    [MenuItem("GameObject/Render into Cubemap")]
    static void RenderCubemap()
    {
        ScriptableWizard.DisplayWizard<RenderCubemapWizard>(
            "Render cubemap", "Render!");
    }
    void ConvertToPng()
    {
        Debug.Log(Application.dataPath + "/" +cubemap.name +"_PositiveX.png");
        var tex = new Texture2D (cubemap.width, cubemap.height, TextureFormat.RGB24, false);
        // Read screen contents into the texture        
        tex.SetPixels(cubemap.GetPixels(CubemapFace.PositiveX));        
        // Encode texture into PNG
        var bytes = tex.EncodeToPNG();      
        File.WriteAllBytes(Application.dataPath + "/"  + cubemap.name +"_PositiveX.png", bytes);       
    
        tex.SetPixels(cubemap.GetPixels(CubemapFace.NegativeX));
        bytes = tex.EncodeToPNG();     
          File.WriteAllBytes(Application.dataPath + "/"  + cubemap.name +"_NegativeX.png", bytes);       
          tex.SetPixels(cubemap.GetPixels(CubemapFace.PositiveY));
          bytes = tex.EncodeToPNG();     
        File.WriteAllBytes(Application.dataPath + "/"  + cubemap.name +"_PositiveY.png", bytes);       
    
          tex.SetPixels(cubemap.GetPixels(CubemapFace.NegativeY));
          bytes = tex.EncodeToPNG();     
          File.WriteAllBytes(Application.dataPath + "/"  + cubemap.name +"_NegativeY.png", bytes);       
          tex.SetPixels(cubemap.GetPixels(CubemapFace.PositiveZ));
          bytes = tex.EncodeToPNG();     
          File.WriteAllBytes(Application.dataPath + "/"  + cubemap.name +"_PositiveZ.png", bytes);       
    
          tex.SetPixels(cubemap.GetPixels(CubemapFace.NegativeZ));
          bytes = tex.EncodeToPNG();     
          File.WriteAllBytes(Application.dataPath + "/"  + cubemap.name   +"_NegativeZ.png", bytes);       
        DestroyImmediate(tex);
        }
    }
