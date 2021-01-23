using System;
using System.Reflection;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(TextAsset))]
public class TestInspector : Editor
{
    private Editor m_editor;
    public override void OnInspectorGUI()
    {
        if (m_editor == null)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var a in assemblies)
            {
                var type = a.GetType("UnityEditor.TextAssetInspector");
                if (type != null)
                {
                    m_editor = Editor.CreateEditor(target, type);
                    break;
                }
            }
        }
        if (m_editor != null)
            m_editor.OnInspectorGUI();
    }
}
