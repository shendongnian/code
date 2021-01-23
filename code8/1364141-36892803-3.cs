    /* Touchable.cs
    
    1 - use Unity's "create Button" function, delete the Text and Image
    components the editor gives you for convenience
    
    2 - drop this on the Button
    
    3 - you now have a correct transparent button
    
    Basically use this to make transparent buttons, since Unity arguably screwed-up
    and did not base things like Text, Graphic on a "Touchable" class concept.
    
    It's a little better to go Touchable:Text rather than building one from scratch
    with :Graphic, since NOTE it will be immune to Unity deprecations;
    always build in autoimmunity when you are backfilling in OO.
    
    Building one from scratch with :Graphic is a good programming exercise and
    you can see many examples on the www but it is unsound; since you're not
    backfilling you have to continually update it with Unity updates.
    
    The nature of what you're creating here is, precisely the "root" functionality
    of (and only of) "Text" so that seems to be the best option.
    */
    
    using UnityEngine;
    using UnityEngine.UI;
    
    #if UNITY_EDITOR
    using UnityEditor;
    [CustomEditor(typeof(Touchable))]
    public class Touchable_Editor : Editor
    	{
    	public override void OnInspectorGUI ()
    		{
    		// prevent treating the component as a Text object in the Editor!
    		}
    	}
    #endif
    
    public class Touchable:Text
    	{
    	protected override void Awake()
    		{
    		base.Awake();
    		}
    	}
