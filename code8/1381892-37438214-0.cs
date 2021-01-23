private float holdOutTime = 2.0f;
private float lastHitTime = 0.0f;
void OnMouseOver() {
    if (Input.GetMouseButtonDown(1)) { IncHitAndShowUI() } //compacted
}
private void Update() {
    if (GUIHit.enabled) { TestAndDisableHitUI(); } //compacted
}
#region priv/helper methods
//would force it inline if it was possible in Unity :)
private void IncHitAndShowUI() {
    HitCounter++;
    lastHitTime = Time.time;
    GUIHit.text = HitCounter.ToString();
    GUIHit.enabled = true;
}
//same here :)
private void TestAndDisableHitUI() {
    if (lastHitTime + holdOutTime >= Time.time) {
       GUIHit.enabled = false;
    }
}
#endregion
