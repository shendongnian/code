    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
    public class NewAnimController : MonoBehaviour {
    public Slider sliderScrubber;
    public Animator animator;
     
    void Start()
    {
        float t = animator
        .GetCurrentAnimatorStateInfo(0)
        .normalizedTime;
        
    }
    public void Update()
    {
        float animationTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
        Debug.Log("animationTime (normalized) is " + animationTime);
        sliderScrubber.value = animationTime;
    }
    public void OnValueChanged(float changedValue)
    {
        animator.speed = 1f;
        animator.Play("Take 001", -1, sliderScrubber.normalizedValue);
    }
    }
