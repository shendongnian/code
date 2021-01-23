    using System;
    using System.Linq;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Attributes.Exporters;
    using BenchmarkDotNet.Attributes.Jobs;
    using BenchmarkDotNet.Running;
    
    [LegacyJitX86Job, LegacyJitX64Job, RyuJitX64Job, MonoJob]
    [RPlotExporter]
    public class CardBenchmarks
    {
      public const int Size = 256;
    
      private float[] result, one;
      private Cards2[] cards2;
      private Cards3[] cards3;
      private Cards4[] cards4;
      private Cards5[] cards5;
      private Cards6[] cards6;
      private Cards7[] cards7;
      private Cards8[] cards8;
    
      [Setup]
      public void Setup()
      {
        result = ArrayUtils.CreateRandomFloatArray(Size);
        one = ArrayUtils.CreateRandomFloatArray(size: 52);
        var c0 = ArrayUtils.RandomByteArray(Size, minValue: 0, maxValueInclusive: 51);
        var c1 = ArrayUtils.RandomByteArray(Size, minValue: 0, maxValueInclusive: 51);
    
        cards2 = CardUtls.Create2(c0, c1);
        cards3 = CardUtls.Create3(c0, c1);
        cards4 = CardUtls.Create4(c0, c1);
        cards5 = CardUtls.Create5(c0, c1);
        cards6 = CardUtls.Create6(c0, c1);
        cards7 = CardUtls.Create7(c0, c1);
        cards8 = CardUtls.Create8(c0, c1);
      }
    
      [Benchmark(OperationsPerInvoke = Size)]
      public void C2()
      {
        for (var i = 0; i < result.Length; i++)
        {
          var c = cards2[i];
          result[i] -= one[c.C0] + one[c.C1];
        }
      }
    
      [Benchmark(OperationsPerInvoke = Size)]
      public void C3()
      {
        for (var i = 0; i < result.Length; i++)
        {
          var c = cards3[i];
          result[i] -= one[c.C0] + one[c.C1];
        }
      }
    
      [Benchmark(OperationsPerInvoke = Size)]
      public void C4()
      {
        for (var i = 0; i < result.Length; i++)
        {
          var c = cards4[i];
          result[i] -= one[c.C0] + one[c.C1];
        }
      }
    
      [Benchmark(OperationsPerInvoke = Size)]
      public void C5()
      {
        for (var i = 0; i < result.Length; i++)
        {
          var c = cards5[i];
          result[i] -= one[c.C0] + one[c.C1];
        }
      }
    
      [Benchmark(OperationsPerInvoke = Size)]
      public void C6()
      {
        for (var i = 0; i < result.Length; i++)
        {
          var c = cards6[i];
          result[i] -= one[c.C0] + one[c.C1];
        }
      }
    
      [Benchmark(OperationsPerInvoke = Size)]
      public void C7()
      {
        for (var i = 0; i < result.Length; i++)
        {
          var c = cards7[i];
          result[i] -= one[c.C0] + one[c.C1];
        }
      }
    
      [Benchmark(OperationsPerInvoke = Size)]
      public void C8()
      {
        for (var i = 0; i < result.Length; i++)
        {
          var c = cards8[i];
          result[i] -= one[c.C0] + one[c.C1];
        }
      }
    }
    
    public static class ArrayUtils
    {
      private static readonly Random Rand = new Random(137);
    
      public static float[] CreateRandomFloatArray(int size)
      {
        var result = new float[size];
        for (int i = 0; i < size; i++)
          result[i] = (float) Rand.NextDouble();
        return result;
      }
    
      public static byte[] RandomByteArray(int size, int minValue, int maxValueInclusive)
      {
        var result = new byte[size];
        for (int i = 0; i < size; i++)
          result[i] = (byte) Rand.Next(minValue, maxValueInclusive + 1);
        return result;
      }
    }
    
    public static class CardUtls
    {
      private static T[] Create<T>(int length, Func<int, T> create) => Enumerable.Range(0, length).Select(create).ToArray();
    
      public static Cards2[] Create2(byte[] c0, byte[] c1) => Create(c0.Length, i => new Cards2 {C0 = c0[i], C1 = c1[i]});
      public static Cards3[] Create3(byte[] c0, byte[] c1) => Create(c0.Length, i => new Cards3 {C0 = c0[i], C1 = c1[i]});
      public static Cards4[] Create4(byte[] c0, byte[] c1) => Create(c0.Length, i => new Cards4 {C0 = c0[i], C1 = c1[i]});
      public static Cards5[] Create5(byte[] c0, byte[] c1) => Create(c0.Length, i => new Cards5 {C0 = c0[i], C1 = c1[i]});
      public static Cards6[] Create6(byte[] c0, byte[] c1) => Create(c0.Length, i => new Cards6 {C0 = c0[i], C1 = c1[i]});
      public static Cards7[] Create7(byte[] c0, byte[] c1) => Create(c0.Length, i => new Cards7 {C0 = c0[i], C1 = c1[i]});
      public static Cards8[] Create8(byte[] c0, byte[] c1) => Create(c0.Length, i => new Cards8 {C0 = c0[i], C1 = c1[i]});
    }
    
    public struct Cards2
    {
      public byte C0, C1;
    }
    
    public struct Cards3
    {
      public byte C0, C1, C2;
    }
    
    public struct Cards4
    {
      public byte C0, C1, C2, C3;
    }
    
    public struct Cards5
    {
      public byte C0, C1, C2, C3, C4;
    }
    
    public struct Cards6
    {
      public byte C0, C1, C2, C3, C4, C5;
    }
    
    public struct Cards7
    {
      public byte C0, C1, C2, C3, C4, C5, C6;
    }
    
    public struct Cards8
    {
      public byte C0, C1, C2, C3, C4, C5, C6, C7;
    }
    
    
    class Program
    {
      static void Main()
      {
        BenchmarkRunner.Run<CardBenchmarks>();
      }
    }
