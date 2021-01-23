    /* file Touchable.cs
    - use Unity's "create Button" function
    - delete Text, Image the editor gives you for convenience
    - drop this script on the Button
    - you now have a correct, true, transparent button
    - this can not 'decay' with Unity upgrades
    - Bonus, properly "buttonize" ANYTHING ui by dropping such a button on to it.
    */
    
    using UnityEngine;
    using UnityEngine.UI;
    #if UNITY_EDITOR
    using UnityEditor;
    [CustomEditor(typeof(Touchable))]
    public class Touchable_Editor : Editor
     { public override void OnInspectorGUI(){} }
    #endif
    public class Touchable:Text
     { protected override void Awake() {base.Awake();} }
    //end file
