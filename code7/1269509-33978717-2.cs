    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections.Generic;
    using System.Linq;
    using Pathfinding.Serialization.JsonFx;
    using UnityEditor;
    
    public class jsonTest : MonoBehaviour
    {
    public Text text;
    public List<ChapterModel> chapters;
    // Use this for initialization
    void Start()
    {
        chapters = new List<ChapterModel>();
        for (int i = 0; i < 2; i++)
        {
            var cm = new ChapterModel();
            cm.pages = new List<PageModel>();
            cm.id = i;
            for (int j = 0; j < 2; j++)
            {
                var pm = new PageModel();
                pm.BackgroundArt = j.ToString();
                cm.pages.Add(pm);
            }
            chapters.Add(cm);
        }
        string json = JsonWriter.Serialize(chapters);
        //Will end up in in invalid cast:
        //var deserialized = JsonReader.Deserialize<List<ChapterModel>(json);
        //Will be casted to object[] on deserialization:
        //var deserialized = JsonReader.Deserialize(json, typeof (List<ChapterModel>));
        //Will evaluate just fine:
        var deserialized = JsonReader.Deserialize(json, typeof(List<ChapterModel>)) as object[];
        List<ChapterModel> list = deserialized.Select(item => item as ChapterModel).ToList();
        Debug.Log(list.Count);
        }
    }
    [System.Serializable]
    public class ChapterModel
    {
       public int id = -1;
       public List<PageModel> pages;
    }
    [System.Serializable]
    public class PageModel
    {
       public string BackgroundArt,
        ForeAddedArt,
        VFXloop, VFXappeared, VFXnextSlide,
        BGAmbientLoop, BGMusicLoop, BGVoiceLoop,
        VFXSound, MusicSound, VoiceSound;
    }
